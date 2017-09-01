package com.ankamagames.dofus.network.messages.game.actions
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AbstractGameActionWithAckMessage extends AbstractGameActionMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 1001;
       
      
      private var _isInitialized:Boolean = false;
      
      public var waitAckId:int = 0;
      
      public function AbstractGameActionWithAckMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 1001;
      }
      
      public function initAbstractGameActionWithAckMessage(param1:uint = 0, param2:Number = 0, param3:int = 0) : AbstractGameActionWithAckMessage
      {
         super.initAbstractGameActionMessage(param1,param2);
         this.waitAckId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.waitAckId = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AbstractGameActionWithAckMessage(param1);
      }
      
      public function serializeAs_AbstractGameActionWithAckMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractGameActionMessage(param1);
         param1.writeShort(this.waitAckId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AbstractGameActionWithAckMessage(param1);
      }
      
      public function deserializeAs_AbstractGameActionWithAckMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._waitAckIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AbstractGameActionWithAckMessage(param1);
      }
      
      public function deserializeAsyncAs_AbstractGameActionWithAckMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._waitAckIdFunc);
      }
      
      private function _waitAckIdFunc(param1:ICustomDataInput) : void
      {
         this.waitAckId = param1.readShort();
      }
   }
}
