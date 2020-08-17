package com.ankamagames.dofus.network.messages.game.interactive
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class InteractiveUseEndedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6112;
       
      
      private var _isInitialized:Boolean = false;
      
      public var elemId:uint = 0;
      
      public var skillId:uint = 0;
      
      public function InteractiveUseEndedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6112;
      }
      
      public function initInteractiveUseEndedMessage(param1:uint = 0, param2:uint = 0) : InteractiveUseEndedMessage
      {
         this.elemId = param1;
         this.skillId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.elemId = 0;
         this.skillId = 0;
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
         this.serializeAs_InteractiveUseEndedMessage(param1);
      }
      
      public function serializeAs_InteractiveUseEndedMessage(param1:ICustomDataOutput) : void
      {
         if(this.elemId < 0)
         {
            throw new Error("Forbidden value (" + this.elemId + ") on element elemId.");
         }
         param1.writeVarInt(this.elemId);
         if(this.skillId < 0)
         {
            throw new Error("Forbidden value (" + this.skillId + ") on element skillId.");
         }
         param1.writeVarShort(this.skillId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InteractiveUseEndedMessage(param1);
      }
      
      public function deserializeAs_InteractiveUseEndedMessage(param1:ICustomDataInput) : void
      {
         this._elemIdFunc(param1);
         this._skillIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InteractiveUseEndedMessage(param1);
      }
      
      public function deserializeAsyncAs_InteractiveUseEndedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._elemIdFunc);
         param1.addChild(this._skillIdFunc);
      }
      
      private function _elemIdFunc(param1:ICustomDataInput) : void
      {
         this.elemId = param1.readVarUhInt();
         if(this.elemId < 0)
         {
            throw new Error("Forbidden value (" + this.elemId + ") on element of InteractiveUseEndedMessage.elemId.");
         }
      }
      
      private function _skillIdFunc(param1:ICustomDataInput) : void
      {
         this.skillId = param1.readVarUhShort();
         if(this.skillId < 0)
         {
            throw new Error("Forbidden value (" + this.skillId + ") on element of InteractiveUseEndedMessage.skillId.");
         }
      }
   }
}
