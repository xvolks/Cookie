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
   public class SpellVariantActivationMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6705;
       
      
      private var _isInitialized:Boolean = false;
      
      public var result:Boolean = false;
      
      public var activatedSpellId:uint = 0;
      
      public var deactivatedSpellId:uint = 0;
      
      public function SpellVariantActivationMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6705;
      }
      
      public function initSpellVariantActivationMessage(param1:Boolean = false, param2:uint = 0, param3:uint = 0) : SpellVariantActivationMessage
      {
         this.result = param1;
         this.activatedSpellId = param2;
         this.deactivatedSpellId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.result = false;
         this.activatedSpellId = 0;
         this.deactivatedSpellId = 0;
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
         this.serializeAs_SpellVariantActivationMessage(param1);
      }
      
      public function serializeAs_SpellVariantActivationMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.result);
         if(this.activatedSpellId < 0)
         {
            throw new Error("Forbidden value (" + this.activatedSpellId + ") on element activatedSpellId.");
         }
         param1.writeVarShort(this.activatedSpellId);
         if(this.deactivatedSpellId < 0)
         {
            throw new Error("Forbidden value (" + this.deactivatedSpellId + ") on element deactivatedSpellId.");
         }
         param1.writeVarShort(this.deactivatedSpellId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SpellVariantActivationMessage(param1);
      }
      
      public function deserializeAs_SpellVariantActivationMessage(param1:ICustomDataInput) : void
      {
         this._resultFunc(param1);
         this._activatedSpellIdFunc(param1);
         this._deactivatedSpellIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SpellVariantActivationMessage(param1);
      }
      
      public function deserializeAsyncAs_SpellVariantActivationMessage(param1:FuncTree) : void
      {
         param1.addChild(this._resultFunc);
         param1.addChild(this._activatedSpellIdFunc);
         param1.addChild(this._deactivatedSpellIdFunc);
      }
      
      private function _resultFunc(param1:ICustomDataInput) : void
      {
         this.result = param1.readBoolean();
      }
      
      private function _activatedSpellIdFunc(param1:ICustomDataInput) : void
      {
         this.activatedSpellId = param1.readVarUhShort();
         if(this.activatedSpellId < 0)
         {
            throw new Error("Forbidden value (" + this.activatedSpellId + ") on element of SpellVariantActivationMessage.activatedSpellId.");
         }
      }
      
      private function _deactivatedSpellIdFunc(param1:ICustomDataInput) : void
      {
         this.deactivatedSpellId = param1.readVarUhShort();
         if(this.deactivatedSpellId < 0)
         {
            throw new Error("Forbidden value (" + this.deactivatedSpellId + ") on element of SpellVariantActivationMessage.deactivatedSpellId.");
         }
      }
   }
}
