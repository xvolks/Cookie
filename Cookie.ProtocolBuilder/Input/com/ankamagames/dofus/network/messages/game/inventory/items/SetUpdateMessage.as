package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.data.items.effects.ObjectEffect;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class SetUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5503;
       
      
      private var _isInitialized:Boolean = false;
      
      public var setId:uint = 0;
      
      public var setObjects:Vector.<uint>;
      
      public var setEffects:Vector.<ObjectEffect>;
      
      private var _setObjectstree:FuncTree;
      
      private var _setEffectstree:FuncTree;
      
      public function SetUpdateMessage()
      {
         this.setObjects = new Vector.<uint>();
         this.setEffects = new Vector.<ObjectEffect>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5503;
      }
      
      public function initSetUpdateMessage(param1:uint = 0, param2:Vector.<uint> = null, param3:Vector.<ObjectEffect> = null) : SetUpdateMessage
      {
         this.setId = param1;
         this.setObjects = param2;
         this.setEffects = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.setId = 0;
         this.setObjects = new Vector.<uint>();
         this.setEffects = new Vector.<ObjectEffect>();
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
         this.serializeAs_SetUpdateMessage(param1);
      }
      
      public function serializeAs_SetUpdateMessage(param1:ICustomDataOutput) : void
      {
         if(this.setId < 0)
         {
            throw new Error("Forbidden value (" + this.setId + ") on element setId.");
         }
         param1.writeVarShort(this.setId);
         param1.writeShort(this.setObjects.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.setObjects.length)
         {
            if(this.setObjects[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.setObjects[_loc2_] + ") on element 2 (starting at 1) of setObjects.");
            }
            param1.writeVarShort(this.setObjects[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.setEffects.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.setEffects.length)
         {
            param1.writeShort((this.setEffects[_loc3_] as ObjectEffect).getTypeId());
            (this.setEffects[_loc3_] as ObjectEffect).serialize(param1);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SetUpdateMessage(param1);
      }
      
      public function deserializeAs_SetUpdateMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:uint = 0;
         var _loc8_:ObjectEffect = null;
         this._setIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readVarUhShort();
            if(_loc6_ < 0)
            {
               throw new Error("Forbidden value (" + _loc6_ + ") on elements of setObjects.");
            }
            this.setObjects.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = param1.readUnsignedShort();
            _loc8_ = ProtocolTypeManager.getInstance(ObjectEffect,_loc7_);
            _loc8_.deserialize(param1);
            this.setEffects.push(_loc8_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SetUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_SetUpdateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._setIdFunc);
         this._setObjectstree = param1.addChild(this._setObjectstreeFunc);
         this._setEffectstree = param1.addChild(this._setEffectstreeFunc);
      }
      
      private function _setIdFunc(param1:ICustomDataInput) : void
      {
         this.setId = param1.readVarUhShort();
         if(this.setId < 0)
         {
            throw new Error("Forbidden value (" + this.setId + ") on element of SetUpdateMessage.setId.");
         }
      }
      
      private function _setObjectstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._setObjectstree.addChild(this._setObjectsFunc);
            _loc3_++;
         }
      }
      
      private function _setObjectsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of setObjects.");
         }
         this.setObjects.push(_loc2_);
      }
      
      private function _setEffectstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._setEffectstree.addChild(this._setEffectsFunc);
            _loc3_++;
         }
      }
      
      private function _setEffectsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:ObjectEffect = ProtocolTypeManager.getInstance(ObjectEffect,_loc2_);
         _loc3_.deserialize(param1);
         this.setEffects.push(_loc3_);
      }
   }
}
