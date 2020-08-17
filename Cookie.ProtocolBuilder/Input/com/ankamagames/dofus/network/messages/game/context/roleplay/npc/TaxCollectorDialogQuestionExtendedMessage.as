package com.ankamagames.dofus.network.messages.game.context.roleplay.npc
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.BasicGuildInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TaxCollectorDialogQuestionExtendedMessage extends TaxCollectorDialogQuestionBasicMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5615;
       
      
      private var _isInitialized:Boolean = false;
      
      public var maxPods:uint = 0;
      
      public var prospecting:uint = 0;
      
      public var wisdom:uint = 0;
      
      public var taxCollectorsCount:uint = 0;
      
      public var taxCollectorAttack:int = 0;
      
      public var kamas:Number = 0;
      
      public var experience:Number = 0;
      
      public var pods:uint = 0;
      
      public var itemsValue:Number = 0;
      
      public function TaxCollectorDialogQuestionExtendedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5615;
      }
      
      public function initTaxCollectorDialogQuestionExtendedMessage(param1:BasicGuildInformations = null, param2:uint = 0, param3:uint = 0, param4:uint = 0, param5:uint = 0, param6:int = 0, param7:Number = 0, param8:Number = 0, param9:uint = 0, param10:Number = 0) : TaxCollectorDialogQuestionExtendedMessage
      {
         super.initTaxCollectorDialogQuestionBasicMessage(param1);
         this.maxPods = param2;
         this.prospecting = param3;
         this.wisdom = param4;
         this.taxCollectorsCount = param5;
         this.taxCollectorAttack = param6;
         this.kamas = param7;
         this.experience = param8;
         this.pods = param9;
         this.itemsValue = param10;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.maxPods = 0;
         this.prospecting = 0;
         this.wisdom = 0;
         this.taxCollectorsCount = 0;
         this.taxCollectorAttack = 0;
         this.kamas = 0;
         this.experience = 0;
         this.pods = 0;
         this.itemsValue = 0;
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
         this.serializeAs_TaxCollectorDialogQuestionExtendedMessage(param1);
      }
      
      public function serializeAs_TaxCollectorDialogQuestionExtendedMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_TaxCollectorDialogQuestionBasicMessage(param1);
         if(this.maxPods < 0)
         {
            throw new Error("Forbidden value (" + this.maxPods + ") on element maxPods.");
         }
         param1.writeVarShort(this.maxPods);
         if(this.prospecting < 0)
         {
            throw new Error("Forbidden value (" + this.prospecting + ") on element prospecting.");
         }
         param1.writeVarShort(this.prospecting);
         if(this.wisdom < 0)
         {
            throw new Error("Forbidden value (" + this.wisdom + ") on element wisdom.");
         }
         param1.writeVarShort(this.wisdom);
         if(this.taxCollectorsCount < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorsCount + ") on element taxCollectorsCount.");
         }
         param1.writeByte(this.taxCollectorsCount);
         param1.writeInt(this.taxCollectorAttack);
         if(this.kamas < 0 || this.kamas > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.kamas + ") on element kamas.");
         }
         param1.writeVarLong(this.kamas);
         if(this.experience < 0 || this.experience > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experience + ") on element experience.");
         }
         param1.writeVarLong(this.experience);
         if(this.pods < 0)
         {
            throw new Error("Forbidden value (" + this.pods + ") on element pods.");
         }
         param1.writeVarInt(this.pods);
         if(this.itemsValue < 0 || this.itemsValue > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.itemsValue + ") on element itemsValue.");
         }
         param1.writeVarLong(this.itemsValue);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TaxCollectorDialogQuestionExtendedMessage(param1);
      }
      
      public function deserializeAs_TaxCollectorDialogQuestionExtendedMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._maxPodsFunc(param1);
         this._prospectingFunc(param1);
         this._wisdomFunc(param1);
         this._taxCollectorsCountFunc(param1);
         this._taxCollectorAttackFunc(param1);
         this._kamasFunc(param1);
         this._experienceFunc(param1);
         this._podsFunc(param1);
         this._itemsValueFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TaxCollectorDialogQuestionExtendedMessage(param1);
      }
      
      public function deserializeAsyncAs_TaxCollectorDialogQuestionExtendedMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._maxPodsFunc);
         param1.addChild(this._prospectingFunc);
         param1.addChild(this._wisdomFunc);
         param1.addChild(this._taxCollectorsCountFunc);
         param1.addChild(this._taxCollectorAttackFunc);
         param1.addChild(this._kamasFunc);
         param1.addChild(this._experienceFunc);
         param1.addChild(this._podsFunc);
         param1.addChild(this._itemsValueFunc);
      }
      
      private function _maxPodsFunc(param1:ICustomDataInput) : void
      {
         this.maxPods = param1.readVarUhShort();
         if(this.maxPods < 0)
         {
            throw new Error("Forbidden value (" + this.maxPods + ") on element of TaxCollectorDialogQuestionExtendedMessage.maxPods.");
         }
      }
      
      private function _prospectingFunc(param1:ICustomDataInput) : void
      {
         this.prospecting = param1.readVarUhShort();
         if(this.prospecting < 0)
         {
            throw new Error("Forbidden value (" + this.prospecting + ") on element of TaxCollectorDialogQuestionExtendedMessage.prospecting.");
         }
      }
      
      private function _wisdomFunc(param1:ICustomDataInput) : void
      {
         this.wisdom = param1.readVarUhShort();
         if(this.wisdom < 0)
         {
            throw new Error("Forbidden value (" + this.wisdom + ") on element of TaxCollectorDialogQuestionExtendedMessage.wisdom.");
         }
      }
      
      private function _taxCollectorsCountFunc(param1:ICustomDataInput) : void
      {
         this.taxCollectorsCount = param1.readByte();
         if(this.taxCollectorsCount < 0)
         {
            throw new Error("Forbidden value (" + this.taxCollectorsCount + ") on element of TaxCollectorDialogQuestionExtendedMessage.taxCollectorsCount.");
         }
      }
      
      private function _taxCollectorAttackFunc(param1:ICustomDataInput) : void
      {
         this.taxCollectorAttack = param1.readInt();
      }
      
      private function _kamasFunc(param1:ICustomDataInput) : void
      {
         this.kamas = param1.readVarUhLong();
         if(this.kamas < 0 || this.kamas > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.kamas + ") on element of TaxCollectorDialogQuestionExtendedMessage.kamas.");
         }
      }
      
      private function _experienceFunc(param1:ICustomDataInput) : void
      {
         this.experience = param1.readVarUhLong();
         if(this.experience < 0 || this.experience > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experience + ") on element of TaxCollectorDialogQuestionExtendedMessage.experience.");
         }
      }
      
      private function _podsFunc(param1:ICustomDataInput) : void
      {
         this.pods = param1.readVarUhInt();
         if(this.pods < 0)
         {
            throw new Error("Forbidden value (" + this.pods + ") on element of TaxCollectorDialogQuestionExtendedMessage.pods.");
         }
      }
      
      private function _itemsValueFunc(param1:ICustomDataInput) : void
      {
         this.itemsValue = param1.readVarUhLong();
         if(this.itemsValue < 0 || this.itemsValue > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.itemsValue + ") on element of TaxCollectorDialogQuestionExtendedMessage.itemsValue.");
         }
      }
   }
}
