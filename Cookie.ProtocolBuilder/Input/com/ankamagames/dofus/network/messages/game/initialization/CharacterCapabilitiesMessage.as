package com.ankamagames.dofus.network.messages.game.initialization
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CharacterCapabilitiesMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6339;
       
      
      private var _isInitialized:Boolean = false;
      
      public var guildEmblemSymbolCategories:uint = 0;
      
      public function CharacterCapabilitiesMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6339;
      }
      
      public function initCharacterCapabilitiesMessage(param1:uint = 0) : CharacterCapabilitiesMessage
      {
         this.guildEmblemSymbolCategories = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.guildEmblemSymbolCategories = 0;
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
         this.serializeAs_CharacterCapabilitiesMessage(param1);
      }
      
      public function serializeAs_CharacterCapabilitiesMessage(param1:ICustomDataOutput) : void
      {
         if(this.guildEmblemSymbolCategories < 0)
         {
            throw new Error("Forbidden value (" + this.guildEmblemSymbolCategories + ") on element guildEmblemSymbolCategories.");
         }
         param1.writeVarInt(this.guildEmblemSymbolCategories);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterCapabilitiesMessage(param1);
      }
      
      public function deserializeAs_CharacterCapabilitiesMessage(param1:ICustomDataInput) : void
      {
         this._guildEmblemSymbolCategoriesFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterCapabilitiesMessage(param1);
      }
      
      public function deserializeAsyncAs_CharacterCapabilitiesMessage(param1:FuncTree) : void
      {
         param1.addChild(this._guildEmblemSymbolCategoriesFunc);
      }
      
      private function _guildEmblemSymbolCategoriesFunc(param1:ICustomDataInput) : void
      {
         this.guildEmblemSymbolCategories = param1.readVarUhInt();
         if(this.guildEmblemSymbolCategories < 0)
         {
            throw new Error("Forbidden value (" + this.guildEmblemSymbolCategories + ") on element of CharacterCapabilitiesMessage.guildEmblemSymbolCategories.");
         }
      }
   }
}
