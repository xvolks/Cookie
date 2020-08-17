package com.ankamagames.dofus.network.messages.game.context.roleplay.spell
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class SpellModifyRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6655;
       
      
      private var _isInitialized:Boolean = false;
      
      public var spellId:uint = 0;
      
      public var spellLevel:int = 0;
      
      public function SpellModifyRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6655;
      }
      
      public function initSpellModifyRequestMessage(param1:uint = 0, param2:int = 0) : SpellModifyRequestMessage
      {
         this.spellId = param1;
         this.spellLevel = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.spellId = 0;
         this.spellLevel = 0;
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
         this.serializeAs_SpellModifyRequestMessage(param1);
      }
      
      public function serializeAs_SpellModifyRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.spellId < 0)
         {
            throw new Error("Forbidden value (" + this.spellId + ") on element spellId.");
         }
         param1.writeVarShort(this.spellId);
         if(this.spellLevel < 1 || this.spellLevel > 200)
         {
            throw new Error("Forbidden value (" + this.spellLevel + ") on element spellLevel.");
         }
         param1.writeShort(this.spellLevel);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SpellModifyRequestMessage(param1);
      }
      
      public function deserializeAs_SpellModifyRequestMessage(param1:ICustomDataInput) : void
      {
         this._spellIdFunc(param1);
         this._spellLevelFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SpellModifyRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_SpellModifyRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._spellIdFunc);
         param1.addChild(this._spellLevelFunc);
      }
      
      private function _spellIdFunc(param1:ICustomDataInput) : void
      {
         this.spellId = param1.readVarUhShort();
         if(this.spellId < 0)
         {
            throw new Error("Forbidden value (" + this.spellId + ") on element of SpellModifyRequestMessage.spellId.");
         }
      }
      
      private function _spellLevelFunc(param1:ICustomDataInput) : void
      {
         this.spellLevel = param1.readShort();
         if(this.spellLevel < 1 || this.spellLevel > 200)
         {
            throw new Error("Forbidden value (" + this.spellLevel + ") on element of SpellModifyRequestMessage.spellLevel.");
         }
      }
   }
}
