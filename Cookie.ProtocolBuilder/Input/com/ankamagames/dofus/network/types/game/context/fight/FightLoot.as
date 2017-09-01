package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FightLoot implements INetworkType
   {
      
      public static const protocolId:uint = 41;
       
      
      public var objects:Vector.<uint>;
      
      public var kamas:Number = 0;
      
      private var _objectstree:FuncTree;
      
      public function FightLoot()
      {
         this.objects = new Vector.<uint>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 41;
      }
      
      public function initFightLoot(param1:Vector.<uint> = null, param2:Number = 0) : FightLoot
      {
         this.objects = param1;
         this.kamas = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.objects = new Vector.<uint>();
         this.kamas = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightLoot(param1);
      }
      
      public function serializeAs_FightLoot(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.objects.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.objects.length)
         {
            if(this.objects[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.objects[_loc2_] + ") on element 1 (starting at 1) of objects.");
            }
            param1.writeVarShort(this.objects[_loc2_]);
            _loc2_++;
         }
         if(this.kamas < 0 || this.kamas > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.kamas + ") on element kamas.");
         }
         param1.writeVarLong(this.kamas);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightLoot(param1);
      }
      
      public function deserializeAs_FightLoot(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readVarUhShort();
            if(_loc4_ < 0)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of objects.");
            }
            this.objects.push(_loc4_);
            _loc3_++;
         }
         this._kamasFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightLoot(param1);
      }
      
      public function deserializeAsyncAs_FightLoot(param1:FuncTree) : void
      {
         this._objectstree = param1.addChild(this._objectstreeFunc);
         param1.addChild(this._kamasFunc);
      }
      
      private function _objectstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._objectstree.addChild(this._objectsFunc);
            _loc3_++;
         }
      }
      
      private function _objectsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of objects.");
         }
         this.objects.push(_loc2_);
      }
      
      private function _kamasFunc(param1:ICustomDataInput) : void
      {
         this.kamas = param1.readVarUhLong();
         if(this.kamas < 0 || this.kamas > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.kamas + ") on element of FightLoot.kamas.");
         }
      }
   }
}
