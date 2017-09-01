package com.ankamagames.dofus.network.messages.game.actions
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AbstractGameActionMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 1000;
       
      
      private var _isInitialized:Boolean = false;
      
      public var actionId:uint = 0;
      
      public var sourceId:Number = 0;
      
      public function AbstractGameActionMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 1000;
      }
      
      public function initAbstractGameActionMessage(param1:uint = 0, param2:Number = 0) : AbstractGameActionMessage
      {
         this.actionId = param1;
         this.sourceId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.actionId = 0;
         this.sourceId = 0;
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
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AbstractGameActionMessage(param1);
      }
      
      public function serializeAs_AbstractGameActionMessage(param1:ICustomDataOutput) : void
      {
         if(this.actionId < 0)
         {
            throw new Error("Forbidden value (" + this.actionId + ") on element actionId.");
         }
         param1.writeVarShort(this.actionId);
         if(this.sourceId < -9007199254740990 || this.sourceId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.sourceId + ") on element sourceId.");
         }
         param1.writeDouble(this.sourceId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AbstractGameActionMessage(param1);
      }
      
      public function deserializeAs_AbstractGameActionMessage(param1:ICustomDataInput) : void
      {
         this._actionIdFunc(param1);
         this._sourceIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AbstractGameActionMessage(param1);
      }
      
      public function deserializeAsyncAs_AbstractGameActionMessage(param1:FuncTree) : void
      {
         param1.addChild(this._actionIdFunc);
         param1.addChild(this._sourceIdFunc);
      }
      
      private function _actionIdFunc(param1:ICustomDataInput) : void
      {
         this.actionId = param1.readVarUhShort();
         if(this.actionId < 0)
         {
            throw new Error("Forbidden value (" + this.actionId + ") on element of AbstractGameActionMessage.actionId.");
         }
      }
      
      private function _sourceIdFunc(param1:ICustomDataInput) : void
      {
         this.sourceId = param1.readDouble();
         if(this.sourceId < -9007199254740990 || this.sourceId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.sourceId + ") on element of AbstractGameActionMessage.sourceId.");
         }
      }
   }
}
