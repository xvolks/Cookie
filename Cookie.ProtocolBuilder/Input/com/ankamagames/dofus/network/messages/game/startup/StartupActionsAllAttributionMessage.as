package com.ankamagames.dofus.network.messages.game.startup
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class StartupActionsAllAttributionMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6537;
       
      
      private var _isInitialized:Boolean = false;
      
      public var characterId:Number = 0;
      
      public function StartupActionsAllAttributionMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6537;
      }
      
      public function initStartupActionsAllAttributionMessage(param1:Number = 0) : StartupActionsAllAttributionMessage
      {
         this.characterId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.characterId = 0;
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
         this.serializeAs_StartupActionsAllAttributionMessage(param1);
      }
      
      public function serializeAs_StartupActionsAllAttributionMessage(param1:ICustomDataOutput) : void
      {
         if(this.characterId < 0 || this.characterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.characterId + ") on element characterId.");
         }
         param1.writeVarLong(this.characterId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_StartupActionsAllAttributionMessage(param1);
      }
      
      public function deserializeAs_StartupActionsAllAttributionMessage(param1:ICustomDataInput) : void
      {
         this._characterIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_StartupActionsAllAttributionMessage(param1);
      }
      
      public function deserializeAsyncAs_StartupActionsAllAttributionMessage(param1:FuncTree) : void
      {
         param1.addChild(this._characterIdFunc);
      }
      
      private function _characterIdFunc(param1:ICustomDataInput) : void
      {
         this.characterId = param1.readVarUhLong();
         if(this.characterId < 0 || this.characterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.characterId + ") on element of StartupActionsAllAttributionMessage.characterId.");
         }
      }
   }
}
